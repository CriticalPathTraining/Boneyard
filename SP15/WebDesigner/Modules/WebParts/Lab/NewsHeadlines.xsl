	<xsl:template name="RemoveHtmlTags">
		<xsl:param name="html"/>
		<xsl:choose>
			<xsl:when test="contains($html, '&lt;')">
				<xsl:value-of select="substring-before($html, '&lt;')"/>
				<!-- Recurse through HTML -->
				<xsl:call-template name="RemoveHtmlTags">
					<xsl:with-param name="html" select="substring-after($html, '&gt;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$html"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template name="NewsHeadline" match="Row[@Style='NewsHeadline']" mode="itemstyle">
		<xsl:variable name="SafeLinkUrl">
			<xsl:call-template name="OuterTemplate.GetSafeLink">
				<xsl:with-param name="UrlColumnName" select="'LinkUrl'"/>
			</xsl:call-template>
		</xsl:variable>
		<xsl:variable name="SafeImageUrl">
            <xsl:call-template name="OuterTemplate.GetSafeStaticUrl">
                <xsl:with-param name="UrlColumnName" select="'ImageUrl'"/>
            </xsl:call-template>
        </xsl:variable>
		<xsl:variable name="DisplayTitle">
			<xsl:call-template name="OuterTemplate.GetTitle">
				<xsl:with-param name="Title" select="@Title"/>
				<xsl:with-param name="UrlColumnName" select="'LinkUrl'"/>
			</xsl:call-template>
		</xsl:variable>
		<xsl:variable name="LinkTarget">
			<xsl:if test="@OpenInNewWindow = 'True'" >_blank</xsl:if>
		</xsl:variable>
		<xsl:variable name="TextOnlyBody">
            <xsl:call-template name="RemoveHtmlTags">
                <xsl:with-param name="html" select="@Body" />
            </xsl:call-template>
        </xsl:variable>
		<div id="post" style="">
			<xsl:if test="string-length($SafeImageUrl) != 0">
                <div style="float:left;"> 
                    <a href="{$SafeLinkUrl}">
                      <img class="image" src="{$SafeImageUrl}" title="{@ImageUrlAltText}" width="130"></img>
                    </a>
                </div>
            </xsl:if>
			<div>
				<h2><a href="{$SafeLinkUrl}" target="{$LinkTarget}" title="{@LinkToolTip}">
					<xsl:value-of select="$DisplayTitle"/>
				</a></h2>
			</div>
			<div> posted @ <xsl:value-of select="msxsl:format-date(substring-before(@PublishedDate, ' '), 'MM/dd/yyy ')" /> 
					by <xsl:value-of select="@Author" /> in <xsl:value-of select="@ByLine" />
			</div>
			<div>
				<xsl:value-of select="substring($TextOnlyBody, 0, 200)" disable-output-escaping="yes" />
				<a href="{$SafeLinkUrl}" target="{$LinkTarget}" title="Read more">...</a>
			</div>
			<div style="clear:both"></div>
		</div>
	</xsl:template>